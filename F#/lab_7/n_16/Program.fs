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

let task57 list =
    let i_list = List.indexed list
    List.fold (fun s x -> if ((List.fold (fun sum b -> snd b + s) 0 (List.takeWhile (fun y -> fst y < fst x) i_list))) < snd x then s + 1 else s) 0 i_list

[<EntryPoint>]
let main argv =
    let list = input_list (Convert.ToInt32(Console.ReadLine()))
    let a = (list |> task57)-1
    Console.WriteLine a
    0