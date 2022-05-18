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

let task list =
    count (fun x y -> x % 2 = 0) list 0

[<EntryPoint>]
let main argv =
    let n = Convert.ToInt32(Console.ReadLine())
    let list = input_list n
    list |> task |> Console.WriteLine
    0
