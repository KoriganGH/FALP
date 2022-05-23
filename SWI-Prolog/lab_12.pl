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
