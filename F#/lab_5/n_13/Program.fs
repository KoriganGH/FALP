open System

//* ↓↑
let rec mult x =
    if x = 0 then 1
    else x%10 * mult(x/10)

//* ↑↓
let mult2 x =
    let rec mult22 x cur =
        if x = 0 then cur
        else 
            let new_cur = x%10 * cur 
            let new_x = x/10
            mult22 new_x new_cur
    mult22 x 1

//min ↓↑
let rec min1 x =
    if x < 10 then x
    else min (x % 10) (min1 (x / 10))

//min ↑↓
let min2 x =
    let rec mup x cur =
        if x=0 then cur
        else    
            let new_cur = if x%10 < cur then x%10 else cur
            let new_x = x/10
            mup new_x new_cur
    mup x 10 

//max ↓↑
let rec max1 x =
    if x < 10 then x
    else max (x % 10) (max1 (x / 10))

///max ↑↓
let max2 x =
    let rec max22 x cur =
        if x=0 then cur
        else    
            let new_cur = if x%10 > cur then x%10 else cur
            let new_x = x/10
            max22 new_x new_cur
    max22 x -1

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("multiplication ↑: {0}", mult x)
    Console.WriteLine("multiplication ↓: {0}", mult2 x)
    Console.WriteLine("min ↑: {0}", min1 x)
    Console.WriteLine("min ↓: {0}", min2 x)
    Console.WriteLine("max ↑: {0}", max1 x)
    Console.WriteLine("max ↓: {0}", max2 x)
    0 
