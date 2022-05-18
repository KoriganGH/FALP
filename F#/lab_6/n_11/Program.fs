open System

let rec input_list n=
    if n = 0 then []
    else 
        let head = Convert.ToInt32(Console.ReadLine())
        let tail = input_list (n - 1)
        head::tail

let rec count f list c =
    match list with 
    |h::t -> if f h t then count f t (c + 1) else count f t c
    |[] -> c

let rec diff f list =
    match list with
    |h::t -> if f h then h else diff f t 
    |[] -> 0

let task list =
    let e1 = List.head list
    let e2 = diff (fun x -> x <> e1) list
    let c1 = count (fun x y -> x = e1) list 0
    let c2 = count (fun x y -> x = e2) list 0
    if c1 > c2 then Console.WriteLine("Элемент, отличный от остальных {0}", e2) 
    else Console.WriteLine("Элемент, отличный от остальных {0}", e1) 

[<EntryPoint>]
let main argv =
    let n = Convert.ToInt32(Console.ReadLine())
    let list = input_list n
    task <| list
    0
