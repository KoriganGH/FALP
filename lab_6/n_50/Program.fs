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

let rec obhod f list =
    match list with
    |h::t -> if f h then obhod f t else false
    |[] -> true

let rec uniq list1 list2 new_list =
    match list1 with
    |h::t -> if (obhod (fun x -> x <> h) list2) then uniq t list2 (h::new_list) else uniq t list2 new_list
    |[] -> new_list

let rec delete_clon list list2 new_list =
    match list with 
    |h::t -> if count (fun x y-> x = h) list2 0 = 1 then delete_clon t list2 (h::new_list) else delete_clon t list2 new_list
    |[] -> new_list

let task (list1,list2:int list) =
    let list_1 = delete_clon list1 list1 []
    let list_2 = delete_clon list2 list2 []
    (uniq list_1 list_2 []) @ (uniq list_2 list_1 [])

[<EntryPoint>]
let main argv =
    let n = Convert.ToInt32(Console.ReadLine())
    let list = input_list n
    let m = Convert.ToInt32(Console.ReadLine()) 
    let list2 = input_list m
    (list,list2) |> task |> output_list |> ignore 
    0