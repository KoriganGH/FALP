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

let rec count f list c =
    match list with 
    |h::t -> if f h t then count f t (c + 1) else count f t c
    |[] -> c

let rec ix f list (counter:int) new_list =
    match list with
    |h::t -> if t <> [] then (if f h t then ix f t (counter + 1) ((counter + 1)::new_list) else ix f t (counter + 1) new_list) else new_list 
    |[] -> new_list

let task list =
    let pos = ix (fun x y -> x > List.head y) list 0 []
    pos |> output_list |> ignore
    Console.WriteLine("\nКол-во:{0}", count (fun x y -> true) pos 0)

[<EntryPoint>]
let main argv =
    let n = Convert.ToInt32(Console.ReadLine())
    let list = input_list n
    list |> task |> Console.WriteLine
    0