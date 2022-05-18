open System

let sum x=
    let rec sum1 c x=
        if x = 0 then c
        else sum1 (c + (x % 10)) (x / 10)
    sum1 0 x

let rec m3 x y c=
    if x < y then c 
        else 
        if (x % y = 0) && (sum x > sum y) then m3 x (y+1) (c * y) 
        else m3 x (y+1) c

[<EntryPoint>]
let main argv =
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine(m3 x 1 1);
    0
