open System
let obhod x func init =
    let rec obhod_del x func init del =
       if(del = 0) then init
       else
          let new_init = if x%del = 0 then func init del else init
          let new_del = del - 1
          obhod_del x func new_init new_del
    obhod_del x func init x

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите x")
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Ответ")
    Console.WriteLine(obhod x (fun x y -> x * y) 1)
    0