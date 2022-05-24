%11
prime(X):-X1 is X-1, prime(X,X1).
prime(_,1):- !.
prime(X,Y) :- 0 is X mod Y,!, fail.
prime(X,Y):- Y1 is Y-1, prime(X,Y1).

sprime_up(X,Sum):-sprime_up(X,X,Sum),!.
sprime_up(_,0,0):-!.
sprime_up(X,Del,Sum):-D1 is Del-1, sprime_up(X,D1,NewSum), (0 is X mod Del,prime(Del), Sum is NewSum+Del; Sum is NewSum).

sprime_down(X,Sum):-sprime_down(X,X,Sum,0),!.
sprime_down(_,0,Sum,Sum):-!.
sprime_down(X,Del,Sum,CurSum):-(0 is X mod Del,prime(Del), NewSum is CurSum+Del; NewSum is CurSum),D1 is Del-1, sprime_down(X,D1,Sum,NewSum).

%12
digit_sum(N,X):-digit_sum(N,0,X).
digit_sum(0,Sum,Sum):-!.
digit_sum(N,Sum,X):-NewN is N div 10,NewSum is (N mod 10)+Sum,digit_sum(NewN,NewSum,X).

mult_del(N,M):-mult_del(N,2,1,M),!.
mult_del(N,N,TM,TM):-!.
mult_del(N,Y,TM,M):-N mod Y =:= 0,digit_sum(Y,X),digit_sum(N,U),X<U->NewY is Y+1,NewTM is TM*Y,mult_del(N,NewY,NewTM,M);NewY is Y+1,mult_del(N,NewY,TM,M).

%14
lenght_list([],0).
lenght_list([_|T],X):-lenght_list(T,X1),X is X1+1.

%
append([],X,X).
append([H|T],X,[H|T1]):-append(T,X,T1).

read_list(A,N):-read_list([],A,0,N).
read_list(A,A,N,N):-!.
read_list(List,A,I,N):-	I1 is I+1,read(X),append(List,[X],List1),read_list(List1,A,I1,N).

write_list([]):-!.
write_list([H|T]):-write(H),write(' '),write_list(T).
%

%15(7)
last([], _, _):-!, fail.
last([H], H, []):-!.
last([H|T], R, [H|RL]):-last(T, R, RL).

sdvig(L,[E|RL]):-last(L,E,RL),!.
sdvig_2(L,[E|RL]):-sdvig(L,R),sdvig(R,[E|RL]).

n_15(N):-read_list(List,N),sdvig_2(List,List2),write_list(List2).

%16(11)
count_el(N,List,Count):-count_el(N,List,Count,0),!.
count_el(_,[],Count,Count).
count_el(N,[H|T],Count,TCount):-(N =:= H -> NewTCount is TCount+1,count_el(N,T,Count,NewTCount);count_el(N,T,Count,TCount)).

count_list(List,List_counts):-count_list(List,List,List_counts,[]),!.
count_list([],_,L,L):-!.
count_list([H|T],List,List_counts,TList):-count_el(H,List,Count),append(TList,[Count],NewTList),count_list(T,List,List_counts,NewTList).

solo(List,X):-count_list(List,List_counts),solo(X,List,List_counts),!.
solo(X,[X|_],[1|_]):-!.
solo(X,[H|T],[HC|TC]):-solo(X,T,TC).

n_16(N):-read_list(List,N),solo(List,X),write(X).

%17(17)
max([H|T],X):-max(T,X,H),!.
max([],X,X):-!.
max([H|T],X,TMax):-H > TMax -> max(T,X,H);max(T,X,TMax).

min([H|T],X):-min(T,X,H),!.
min([],X,X):-!.
min([H|T],X,TMin):-H < TMin -> min(T,X,H);min(T,X,TMin).

swap(N,M,List,X):-swap(N,M,List,[],X),!.
swap(_,_,[],X,X):-!.
swap(N,M,[H|T],NewList,X):-(H =:= N -> append(NewList,[M],NewNewList),swap(N,M,T,NewNewList,X);(H =:= M -> append(NewList,[N],NewNewList),swap(N,M,T,NewNewList,X);append(NewList,[H],NewNewList),swap(N,M,T,NewNewList,X))),!.

n_17(N):-read_list(List,N),min(List,X),max(List,Y),swap(X,Y,List,NewList),write_list(NewList).

%18(19)
n_18(N):-read_list(List,N),sdvig(List, NewList),write_list(NewList).
