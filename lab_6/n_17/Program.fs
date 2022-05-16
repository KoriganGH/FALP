open System

let rec input_list n=
    if n = 0 then []
    else 
        let head = Convert.ToInt32(Console.ReadLine())
        let tail = input_list (n - 1)
        head::tail

let rec output_list (list:int list) =
    match list with
    |[] -> None
    |h::t-> Console.Write("{0} ", h)
            output_list t

let rec flip list (newlist:int list)=
    match list with 
    |h::t -> flip t (h::newlist)
    |[] -> newlist

let rec swap list x y new_list =
    match list with
    |h::t -> if h = x  then swap t x y (y::new_list) else if h = y then swap t x y (x::new_list) else swap t x y (h::new_list)
    |[] -> flip new_list []

let rec universal f list c =
    match list with
    |h::t -> universal f t (f h c)
    |[] -> c

let task list =
    let max = universal (fun x y -> if x > y then x else y) list (List.head list)
    let min = universal (fun x y -> if x < y then x else y) list (List.head list)
    swap list min max []

[<EntryPoint>]
let main argv =
    let n = Convert.ToInt32(Console.ReadLine())
    let list = input_list n
    list |> task |> output_list |> ignore
    0