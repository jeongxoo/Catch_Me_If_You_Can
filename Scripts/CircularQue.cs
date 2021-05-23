using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularQue : MonoBehaviour
{
    private static CircularQue instance;
    public static CircularQue Instance
    {
        get
        {
            return instance;
        }
    }

    const int maxSize = 7;
    public GameObject[] circularQue;
    private int head = 0;
    private int tail = 0;

    bool IsEmpty() {
        return head == tail;
    }
    bool IsFull() {
        return (tail + 1) % maxSize == head;
    }

    public void Enqueue(GameObject trap) {
        if (!IsFull()) {
            tail = (tail + 1) % maxSize;
            circularQue[tail] = trap;
        }
    }

    public GameObject Dequeue() {
        if (!IsEmpty()) {
            head = (head + 1) % maxSize;
            return circularQue[head];
        } else {
            return null;
        }
    }
}
