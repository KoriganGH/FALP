append([],X,X).
append([H|T],X,[H|T1]):-append(T,X,T1).

read_list(List,N):-read_list(List,N,[],0),!.
read_list(List,N,List,N):-!.
read_list(List,N,NewList,I):-NewI is I+1,read(X),append(NewList,[X],NewNewList),read_list(List,N,NewNewList,NewI).

write_list([]):-!.
write_list([H|T]):-write(H),write(' '),write_list(T).

%11(37)
index_list(List,Answer):-index_list(List,[],0,Answer).
index_list([H|[]],ListIndex,_,ListIndex):-!.
index_list([H1,H2|T],ListIndex,I,Answer):-NewI is I+1,(H2 < H1 -> append(ListIndex,[NewI],NewListIndex),index_list([H2|T],NewListIndex,NewI,Answer);index_list([H2|T],ListIndex,NewI,Answer)).

lenght_list([],0).
lenght_list([_|T],X):-lenght_list(T,X1),X is X1+1,!.

n_11(N):-read_list(List,N),index_list(List,IndexList),lenght_list(IndexList,X),write(X),nl,write_list(IndexList).
