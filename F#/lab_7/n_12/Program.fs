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

let task17 (list:int list) =
    let min = List.min list
    let max = List.max list
    List.map (fun x -> if x = max then min else if x = min then max else x) list

[<EntryPoint>]
let main argv =
    let list = input_list (Convert.ToInt32(Console.ReadLine()))
    list |> task17 |> output_list |> ignore
    0
