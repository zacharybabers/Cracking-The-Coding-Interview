using System;
using System.Collections.Generic;

class ChapterTwo {
  public static void Main (string[] args) {
    LinkedList<int> list1 = new LinkedList<int>();
    list1.AddLast(new LinkedListNode<int>(5));
    list1.AddLast(new LinkedListNode<int>(3));
    list1.AddLast(new LinkedListNode<int>(2));
    list1.AddLast(new LinkedListNode<int>(5));
    list1.AddLast(new LinkedListNode<int>(9));
    list1.AddLast(new LinkedListNode<int>(10));
    list1.AddLast(new LinkedListNode<int>(5));
    LinkedList<int> list2 = new LinkedList<int>();
    list2.AddLast(new LinkedListNode<int>(-3));
    list2.AddLast(new LinkedListNode<int>(-4));
    list2.AddLast(new LinkedListNode<int>(-5));
    list2.AddLast(new LinkedListNode<int>(-6));
    list2.AddLast(new LinkedListNode<int>(10));
    list2.AddLast(new LinkedListNode<int>(-8));
    list2.AddLast(new LinkedListNode<int>(-10));
    PrintList(list1);
    PrintList(list2);
    Console.WriteLine(ListIntersection(list1, list2));
  }
  public static void RemoveDups(LinkedList<int> list){
    Dictionary<int, int> dupeTracker = new Dictionary<int,int>();

    LinkedListNode<int> currNode = list.First;
    while(currNode != null){
      if(dupeTracker.ContainsKey(currNode.Value)){
        var tempNode = currNode;
        currNode = currNode.Next;
        list.Remove(tempNode);
      }else{
        dupeTracker.Add(currNode.Value, currNode.Value);
        currNode = currNode.Next;
      }
    }
  }
  public static void PrintList(LinkedList<int> list){
    string toPrint = "";
    var currNode = list.First;

    
    while(currNode !=null){
      toPrint += currNode.Value + ", ";
      currNode = currNode.Next;
    }
    Console.WriteLine(toPrint);
  }
  public static LinkedListNode<int> KthToLast(LinkedList<int> list, int k){
    int distance = k-1;
    var fastPointer = list.First;
    var slowPointer = list.First;
    for(int i = 0; i < distance; i++){
      fastPointer = fastPointer.Next;
    }
    while(fastPointer.Next != null){
      fastPointer = fastPointer.Next;
      slowPointer = slowPointer.Next;
    }
    return slowPointer;
  }
  public static void DeleteMiddleNode(LinkedListNode<int> node, LinkedList<int> list){
    node.Value = node.Next.Value;
    list.Remove(node.Next);
  }
  public static void Partition(LinkedList<int> list, int partitionValue){
    var partitionPointer = list.First;
    var movingPointer = list.First.Next;
    while(movingPointer != null){
      var possibleNext = movingPointer.Next;
      if(movingPointer.Value < partitionValue){
        var tempValue = movingPointer.Value;
        list.AddBefore(partitionPointer, tempValue);
        list.Remove(movingPointer);
      }
        movingPointer = possibleNext;
      
    }
  }
  public static bool LinkedPalindrome(LinkedList<int> list){
    Stack<int> myStack = new Stack<int>();
    var currNode = list.First;
    while(currNode != null){
      myStack.Push(currNode.Value);
      currNode = currNode.Next;
    }
    currNode = list.First;
    for(int i = 0; i < list.Count; i++){
      if(myStack.Pop() != currNode.Value){
        return false;
      }
      currNode = currNode.Next;
    }

    return true;
  }
  public static int ListIntersection(LinkedList<int> list1, LinkedList<int> list2){
    Dictionary<int, int> nodeMap = new Dictionary<int, int>();
    var currNode = list1.First;
    while(currNode != null){
      if(!nodeMap.ContainsKey(currNode.Value)){
         nodeMap.Add(currNode.Value, currNode.Value);
      }
      currNode = currNode.Next;
    }
    currNode = list2.First;
    while(currNode! != null){
      if(nodeMap.ContainsKey(currNode.Value)){
        return currNode.Value;
      }
      currNode = currNode.Next;
    }
    return 0;
  }
  public static LinkedListNode<int> LoopDetection(LinkedList<int> list){
    Dictionary<LinkedListNode<int>, int> nodeMap = new Dictionary<LinkedListNode<int>, int>();
    var currNode = list.First;
    while(currNode != null){
      if(!nodeMap.ContainsKey(currNode)){
        nodeMap.Add(currNode, currNode.Value);
      }
      else{
        return currNode;
      }
      currNode = currNode.Next;
    }
    return list.First;
  }
}