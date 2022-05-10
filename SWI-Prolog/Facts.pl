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
