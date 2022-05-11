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
woman(temp_sis).

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
