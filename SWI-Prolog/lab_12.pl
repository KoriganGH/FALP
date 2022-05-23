%11
prime(X):-X1 is X-1, prime(X,X1).
prime(_,1):- !.
prime(X,Y) :- 0 is X mod Y,!, fail.
prime(X,Y):- Y1 is Y-1, prime(X,Y1).

sprime_up(X,Sum):-sprime_up(X,X,Sum),!.
sprime_up(_,0,0):-!.
sprime_up(X,Del,Sum):-D1 is Del-1, sprime_up(X,D1,NewSum), (0 is X mod Del,prime(Del), Sum is NewSum+Del; Sum is NewSum).
