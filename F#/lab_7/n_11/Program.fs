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

let task7 (list:int list) =
    (List.last list::List.removeAt (List.length list - 1) list)

[<EntryPoint>]
let main argv =
    let list = input_list (Convert.ToInt32(Console.ReadLine()))
    list |> task7 |> task7 |> output_list |> ignore
    0