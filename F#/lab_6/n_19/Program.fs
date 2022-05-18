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

let task list =
    let head = List.head list
    let rec task1 list new_list=
        match list with
        |h::t -> task1 t (h::new_list)
        |[] -> flip (head::new_list) []
    task1 (List.tail list) []

[<EntryPoint>]
let main argv =
    let m = Convert.ToInt32(Console.ReadLine())
    let list = input_list m
    list |> task |> output_list |> ignore
    0
