using System;
using System.Collections.Generic;
/*
class Program {
  public static void Main (string[] args) {
    
  }


}
*/
class SetOfStacks<T> {
  private int capacity;
  private MultiStack<T> headStack;
  
  public SetOfStacks(int capacity){
    this.capacity = capacity;
    headStack = new MultiStack<T>(null);
  }

  public void Push(T item){
    if(headStack.myStack.Count >= capacity){
      var temp = headStack;
      headStack = new MultiStack<T>(temp);
      headStack.myStack.Push(item);
    }else{
      headStack.myStack.Push(item);
    }
  }

  public T Pop(){
    if(headStack.myStack.Count >= 2){
      return headStack.myStack.Pop();
    }else if(headStack.Next != null){
      var retrieved = headStack.myStack.Pop();
      headStack = headStack.Next;
      return retrieved;
    }else{
      return headStack.myStack.Pop();
    }
  }

  public PopAt(int index){
    MultiStack<T> multiStack = headStack;
    for(int i = 0; i < index; i++){
      multiStack = multiStack.Next;
    }

    return multiStack.myStack.Pop();
  }
  

  
}

class MultiStack<T> {
  public Stack<T> myStack;
  public MultiStack<T> Next;

  public MultiStack(MultiStack<T> next){
    myStack = new Stack<T>();
    Next = next;
  }
}