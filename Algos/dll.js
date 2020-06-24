class DLNode {
    constructor(value){
        this.value = value;
        this.next = null;
        this.prev = null;
    }
}


class DLList {
    constructor(){
        this.head = null;
    }

    // Write a method that will return whether or not the 
    // doubly linked list is empty.
    isEmpty(){
        return this.head === null;
    }

    // Write a method that will add a new node to the end of our
    // doubly linked list.
    append(value) {
        if(this.isEmpty()){
            this.head = new DLNode(value);
            return this;
        }
        let runner = this.head;
        while(runner.next != null){
            runner = runner.next;
        }
        let newNode = new DLNode(value);
        runner.next = newNode;
        newNode.prev = runner;
        return this;
    }

    // Write a method that will add a new node to the beginning of
    // our doubly linked list.
    prepend(value) {
        let newNode = new DLNode(value);
        newNode.next = this.head;
        if(this.head != null){
            this.head.prev = newNode;
        }
        this.head = newNode;
        return this;
    }

    // Write a method that will add a new node at a given "index" of our
    // doubly linked list

    // NOTE! Test for if the index given is out of range!
    push(value, index){
        if(index < 0) {
            console.log("C'mon, that's not an index.");
            return this;
        }
        if(this.isEmpty()) {
            if(index > 0){
                console.log("No can do grizzly bear.");
                return this;
            }
            else {
                this.head = new DLNode(value);
                return this;
            }
        }
        if(index == 0){
            this.prepend(value);
            return this;
        }
        
        let runner = this.head;
        let newNode = new DLNode(value);
        for(var i = 1; i < index; i++){
            if(runner == null){
                console.log("No");
                return this;
            }
            runner = runner.next;
        }
        newNode.next = runner.next;
        newNode.prev = runner;
        runner.next = newNode;
        newNode.next.prev = newNode;
        return this;
    }

    printList(){
        if(this.isEmpty()){
            console.log("List is empty.")
            return this;
        }
        let toPrint = "<- ";
        let runner = this.head;
        while(runner.next != null) {
            toPrint += `${runner.value} <-> `;
            runner = runner.next;
        }
        toPrint += `${runner.value} ->`;
        console.log(toPrint);
        return this;
    }
}
