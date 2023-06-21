using Linked_list;

LinkedList ll = new LinkedList();
Node n1 = new Node(1);
Node n2 = new Node(2);
Node n3 = new Node(3);

ll.AddNodeToFront(n1);
ll.AddNodeToFront(n2);
ll.AddNodeToFront(n3);
ll.PrintLinkedList();

Console.WriteLine();

//ll.RemoveNode(n3);
//ll.PrintLinkedList();

ll.ReverseLinkedList();




