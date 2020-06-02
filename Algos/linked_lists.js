// This is the class for our Singly Linked Node
class SLNode {
    // The constructor is built to take 1 parameter, being the value of the node we want
    // to create
    constructor(val) {
        // This is the node's actual value
        this.value = val;
        // And this indicates what is next after the current node.
        this.next = null;
    }
}

class SLList {
    constructor() {
        // This is the beginning of the singly linked list
        this.head = null;
    }

    // Write a method that will return a boolean depending on whether or not the singly
    // linked list is empty or not.
    isEmpty() {
        // An empty list in its most simplified form is a list
        // with a head that is null.

        // So what this does, it it grabs the boolean for head == null, and returns that.
        return this.head == null;

        // Alternative:
        if (this.head==null) {
            return true;
        }
    }

    // Write a method that is given a value, and adds a new node to the end of a SLL
    // where that new node has that value.
    addToBack(value) {
        if(this.isEmpty()){
            this.head = new SLNode(value);
            return this;
        }
        else {
            let runner = this.head;
            while(runner.next != null) {
                runner = runner.next;
            }

            runner.next = new SLNode(value);
            return this;
        }
    }


    // Write a method that prints the contents of a Singly Linked List.
    printList() {
        // Let's start a runner at the beginning of the singly linked list itself
        var runner = this.head;
        // This string will be added to as we traverse along the SLL
        var string = "";


        // Now we need a way to traverse through the SLL

        // If the runner is not null, we're still looking at a node, so we have things to do!
        while(runner != null) {
            // We want to add the node's value to our string, and a fancy little arrow for looks
            string += runner.value + " -> ";
            // Then, we want to progress the runner to the NEXT node in the SLL
            runner = runner.next;
        }
        
        // Once we've finished moving through the entire list, we want to print the string
        console.log(string);
    }
}


var myList = new SLList();

myList.head = new SLNode(5);
myList.head.next = new SLNode(6);
myList.head.next.next = new SLNode(7);

myList.printList();