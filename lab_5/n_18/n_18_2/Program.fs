open System

let m2 x =
    let rec obhod x c=
        if x <= 0 then c else
        if ((x % 10) > 3) && ((x % 10) % 2 > 0) then obhod (x / 10) (c + 1)
        else obhod (x / 10) c
    obhod x 0

[<EntryPoint>]
let main argv =
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine(m2 x)
    0