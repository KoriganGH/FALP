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

let rec search_del n i (new_list:int list) =
    if n < i then new_list
    else (if n % i = 0 then search_del n (i+1) (i::new_list) else search_del n (i+1) new_list)
    
let task47 (list:int list) =
    let distinct_list = List.distinct list
    List.distinct (List.fold (fun s x -> s @ search_del x 1 []) [] distinct_list)

[<EntryPoint>]
let main argv =
    let list = input_list (Convert.ToInt32(Console.ReadLine()))
    list |> task47 |> output_list |> ignore
    0