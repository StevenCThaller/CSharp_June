class BSNode {
    constructor(value){
        this.value = value;
        this.left = null;
        this.right = null;
    }
}

class BSTree {
    constructor(){
        this.root = null;
    }

    // I don't think I need to say anything for this one lol
    isEmpty(){

    }

    // Write a method that will insert a new node into the BST
    insert(value){

    }

    // Write a method that will return the largest element in the BST
    max(){

    }

    // Write a method that will return the smallest element in the BST
    min(){

    }

    printTree(){
        if(this.root == null) {
            console.log("This tree is empty.");
            return this;
        }

        this.printHelper();
    }

    printHelper(toPrint = "", runner = this.root) {
        if(runner == null) {
            return this;
        }

        toPrint += "\t";
        this.printHelper(toPrint, runner.right);
        console.log(`${toPrint}${runner.value}`);
        this.printHelper(toPrint, runner.left);
    }
}