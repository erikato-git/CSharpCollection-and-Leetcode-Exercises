using BFS_DFS_Solutions;

/*
 *             A
 *       B           E
 *    C     D     F     G
 *
 */


Node G = new Node(null,null,"G");
Node F = new Node(null, null, "F");
Node E = new Node(F,G,"E");
Node D = new Node(null, null, "D");
Node C = new Node(null, null, "C");
Node B = new Node(C,D,"B");
Node A = new Node(B,E,"A");

BFS_DFS bd = new BFS_DFS();
bd.bfs_traversal(A);
Console.WriteLine();
bd.dfs_traversal(A);








