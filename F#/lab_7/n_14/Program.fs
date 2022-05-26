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

let task37 (list:int list) =
    let list_indexed = List.indexed list 
    let new_list = List.filter (fun x -> snd x < List.item (fst x - 1) list) (List.tail list_indexed)
    List.iter (fun x -> printfn "index %i" (fst x) ) new_list
    Console.Write("count ")
    Console.WriteLine(List.fold (fun s x -> s+1 ) 0 new_list)

[<EntryPoint>]
let main argv =
    let list = input_list (Convert.ToInt32(Console.ReadLine()))
    list |> task37
    0
