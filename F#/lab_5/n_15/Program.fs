open System

let rec nod a b =
    if a = b then a
    else
        if (a > b) then 
            let new_a = b 
            let new_b = a-b
            nod new_a new_b
        else 
            let new_a = a 
            let new_b = b-a
            nod new_a new_b

let prime num func init =
    let rec count num func init cur = 
        if(cur<=1) then init
        else
            let new_init = if nod num cur = 1 then func cur init else init
            let new_cur = cur-1
            count num func new_init new_cur
    count num func init num

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите x")
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine(prime x (fun x y -> x+y) 1)
    0 
