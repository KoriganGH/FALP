man(dmitry).
man(samuel).
man(georgy).
man(fred).
man(max).
man(henry).
man(jason).
man(ura).
man(lary).
man(michail).

woman(alexandra).
woman(sara).
woman(maria).
woman(sophie).
woman(anastasia).
woman(helen).
woman(julia).

parent(dmitry,sophie).
parent(alexandra,sophie).

parent(max,julia).
parent(anastasia,julia).

parent(samuel,fred).
parent(sara,fred).
parent(samuel,max).
parent(sara,max).

parent(georgy,anastasia).
parent(maria,anastasia).

parent(sophie,henry).
parent(fred,henry).
parent(sophie,jason).
parent(fred,jason).

parent(max,helen).
parent(anastasia,helen).
parent(max,ura).
parent(anastasia,ura).

parent(jason,michail).
parent(helen,michail).
parent(jason,lary).
parent(helen,lary).

father(X,Y):-parent(X,Y),man(X).    % n_11
father(X):-father(Y,X),write(Y).

sister(X,Y):-parent(Z,X),parent(Z,Y),parent(G,X),parent(G,Y),woman(X),woman(Z),man(G),X\=Y.     % n_12
sisters(X):-sister(Y,X),write(Y),nl,fail.

grand_so(X,Y):-parent(V,X),parent(Y,V),man(X).    % n_13
grand_sons(X):-grand_so(Y,X),write(Y),nl,fail.

grand_ma_and_son(X,Y):-woman(X),man(Y),parent(Z,Y),parent(X,Z);man(X),woman(Y),parent(Z,X),parent(Y,Z).  % n_14

mon_up(0,Y):-write(Y),!.                                           % n_15                
mon_up(X,Y):- N is (X div 10),M is (Y*(X mod 10)), mon_up(N,M).       
mon_up(X):-mon_up(X,1).

mon_down(0,1):-!.                                                   % n_16
mon_down(X,Y):-X1 is X div 10,mon_down(X1,Y1),Y is Y1*(X mod 10).     
mon_down(X):-mon_down(X,Y),write(Y).

count_up(0,0):-!.                                                                                               % n_17
count_up(X,Y):- X1 is (X div 10), Z is (X mod 10), count_up(X1,Y1) , (Z>3,Z mod 2 =\=0 -> Y is Y1+1;Y is Y1).
count_up(X):-count_up(X,Y),write(Y).

count_down(X,Y):-count_down(X,Y,0).                                                                                                              % n_18
count_down(0,Result,Result):-!.
count_down(X,Count,CurCount):- X1 is X mod 10, (X1>3,1 is X1 mod 2, NowCount is CurCount+1;NowCount is CurCount), X2 is X div 10, count_down(X2,Count,NowCount). 
                                                                                                                                                                    
fib_up(1,1):-!.                                                                  % n_19
fib_up(2,1):-!.
fib_up(X,Y):- X>1, X1 is X-1,X2 is X-2, fib_up(X1,Y1),fib_up(X2,Y2),Y is Y1+Y2. 

fib_down(N,X):-fib_down(N,1,0,X).                                         % n_20
fib_down(1,Result,_,Result):-!.
fib_down(N,X1,X2,Result):-X is X1+X2, N1 is N-1,fib_down(N1,X,X1,Result).
   

