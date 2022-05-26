open System

let read_array n =
    let rec read_array1 n array = 
        if n = 0 then
            array
        else
            let tail = System.Console.ReadLine() |> Int32.Parse
            let new_array = Array.append array [|tail|]
            let n1 = n - 1
            read_array1 n1 new_array
    read_array1 n Array.empty

let write_array arr =
    printfn "%A" arr

[<EntryPoint>]
let main argv =
    let array1 = read_array (Console.ReadLine() |> Int32.Parse)
    let array2 = read_array (Console.ReadLine() |> Int32.Parse)
    array1 |> Array.filter (fun x -> Array.exists (fun y -> y = x) array2 ) |> write_array
    0