%
append([],X,X).
append([H|T],X,[H|T1]):-append(T,X,T1).

read_list(List,N):-read_list(List,N,[],0),!.
read_list(List,N,List,N):-!.
read_list(List,N,NewList,I):-NewI is I+1,read(X),append(NewList,[X],NewNewList),read_list(List,N,NewNewList,NewI).

write_list([]):-!.
write_list([H|T]):-write(H),write(' '),write_list(T).
%

%11(37)
index_list(List,Answer):-index_list(List,[],0,Answer).
index_list([H|[]],ListIndex,_,ListIndex):-!.
index_list([H1,H2|T],ListIndex,I,Answer):-NewI is I+1,(H2 < H1 -> append(ListIndex,[NewI],NewListIndex),index_list([H2|T],NewListIndex,NewI,Answer);index_list([H2|T],ListIndex,NewI,Answer)).

lenght_list([],0).
lenght_list([_|T],X):-lenght_list(T,X1),X is X1+1,!.

n_11(N):-read_list(List,N),index_list(List,IndexList),lenght_list(IndexList,X),write(X),nl,write_list(IndexList).

%12(50)
srav(N,[]).
srav(N,[H|T]):-N =:= H -> fail,!;srav(N,T).

dif(List1,List2,Answer):-dif(List1,List2,NewList,[]),dif(List2,List1,Answer,NewList).
dif([],List2,Answer,Answer):-!.
dif([H|T],List2,Answer,NewList):-srav(H,List2) -> append(NewList,[H],NewNewList),dif(T,List2,Answer,NewNewList);dif(T,List2,Answer,NewList).

n_12(N,M):-read_list(List1,N),read_list(List2,M),dif(List1,List2,Answer),write_list(Answer).

%
in_list([],_):-fail.
in_list([El|_],El).
in_list([_|T],El):-in_list(T,El).
%

%14
n_14:- Hairs=[_,_,_],
	in_list(Hairs,[belokurov,_]),
	in_list(Hairs,[rizhov,_]),
	in_list(Hairs,[chernov,_]),
	in_list(Hairs,[_,blond]),
	in_list(Hairs,[_,redhead]),
	in_list(Hairs,[_,brunette]),
	not(in_list(Hairs,[belokurov,blond])),
	not(in_list(Hairs,[rizhov,redhead])),
	not(in_list(Hairs,[chernov,brunette])),
	write(Hairs),!.

%15
n_15:- Girls=[_,_,_],
	in_list(Girls,[anna,Z,Z]),
	in_list(Girls,[natalya,_,green]),
	in_list(Girls,[valya,_,_]),
	in_list(Girls,[_,white,_]),
	in_list(Girls,[_,green,_]),
	in_list(Girls,[_,blue,_]),
	in_list(Girls,[_,_,white]),
	in_list(Girls,[_,_,green]),
	in_list(Girls,[_,_,blue]),
	not(in_list(Girls,[valya,Y,Y])),
	not(in_list(Girls,[natalya,X,X])),
	not(in_list(Girls,[valya,white,white])),
	write(Girls),!.
	
%16
n_16:-Friends=[_,_,_],
	in_list(Friends,[slesar,_,0,0,_]),
	in_list(Friends,[tokar,_,_,1,_]),
	in_list(Friends,[svarman,_,_,_,_]),
	in_list(Friends,[_,semenov,_,2,borisov]),
	in_list(Friends,[_,ivanov,_,_,_]),
	in_list(Friends,[_,borisov,1,_,semenov]),
	in_list(Friends,[slesar,Who1,_,_,_]),
	in_list(Friends,[svarman,Who2,_,_,_]),
	in_list(Friends,[tokar,Who3,_,_,_]),
	write('slesar ='),write(Who1),nl,write('svarman ='),write(Who2),nl,write('tokar ='),write(Who3),!.

%17
left(_,_,[]):-fail.
left(A,B,[B,[[B|A]|_]]).
left(A,B,[_|T]):-left(A,B,T).

right(_,_,[]):-fail.
right(A,B,[A|[B|_]]).
right(A,B,[_|T]):-right(A,B,T).

near(A,B,T):-right(A,B,T).
near(A,B,T):-left(A,B,T).

n_17:-Drinks=[_,_,_,_],
	in_list(Drinks,[bottle,_]),
	in_list(Drinks,[glass,_]),
	in_list(Drinks,[jug,_]),
	in_list(Drinks,[pot,_]),
	in_list(Drinks,[_,water]),
	in_list(Drinks,[_,milk]),
	in_list(Drinks,[_,lemonade]),
	in_list(Drinks,[_,kvas]),
	not(in_list(Drinks,[bottle,milk])),
	not(in_list(Drinks,[bottle,water])),
	not(in_list(Drinks,[pot,water])),
	not(in_list(Drinks,[pot,lemonade])),
	right([jug,_],[_,lemonade],Drinks),
	right([_,lemonade],[_,kvas],Drinks),
	near([glass,_],[pot,_],Drinks),
	near([glass,_],[_,milk],Drinks),
	write(Drinks),!.

%18
n_18:-Men=[_,_,_,_],
	in_list(Men,[voronov,_]),
	in_list(Men,[pavlov,_]),
	in_list(Men,[levitskiy,_]),
	in_list(Men,[sahorov,_]),
	in_list(Men,[_,dancer]),
	in_list(Men,[_,artist]),
	in_list(Men,[_,writer]),
	in_list(Men,[_,singer]),
	not(in_list(Men,[voronov,singer])),
	not(in_list(Men,[levitskiy,singer])),
	not(in_list(Men,[pavlov,writer])),
	not(in_list(Men,[pavlov,artist])),
	not(in_list(Men,[voronov,writer])),
	not(in_list(Men,[sahorov,writer])),
	write(Men),!.
