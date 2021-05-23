using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private static Stack instance;
    const int maxSize = 10;
    public GameObject[] stack;
    int top = -1;

    public static Stack Instance
    {
        get
        {
            return instance;
        }
    }

    public bool IsEmpty() {
        return top == -1;
    }

    public bool IsFull() {
        return top == maxSize;
    }

    public void Push(GameObject trap) {
        if (!IsFull()) {
            stack[++top] = trap;
        }
    }

    public void Clear() {
        // stack.clear();
    }

    public GameObject Peek() {
        if (!IsEmpty()) {
            return stack[top];
        } else {
            return stack[0];
        }
    }

    public GameObject Pop() {
        if (!IsEmpty()) {
            return stack[top--];
        } else {
            return null;
        }
    }
}
