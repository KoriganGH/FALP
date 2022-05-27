open System

let task1 str = 
    let res1 = String.length(String.filter (fun x -> x>='А' && x<='я') str)
    Console.WriteLine(res1)

let f n str  = 
    match n with 
    |1 -> Convert.ToString(task1 str)
    
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку: ")
    let str = Console.ReadLine()
    Console.WriteLine("Введите номер задания: ")
    let n = Console.ReadLine() |> Convert.ToInt32
    f n str |> ignore 
    0