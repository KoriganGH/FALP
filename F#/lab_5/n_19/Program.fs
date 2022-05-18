open System

let rec create_del_list n j r=
    if n < j then r 
    else 
        if n % j = 0 then create_del_list n (j+1) (j::r)
        else create_del_list n (j+1) r

let rec sum_list list sum predicate=
    match list with
    |h::t -> if predicate h then sum_list t (sum+h) predicate else sum_list t sum predicate
    | _ -> sum

let rec mult_list list mul predicate=
    match list with
    |h::t -> if predicate h then mult_list t (mul * h) predicate else mult_list t mul predicate
    | _ -> mul

let sum_c_t n=
    let rec sum_c_t1 acc n=
        if n = 0 then acc
        else sum_c_t1 (acc + (n % 10)) (n / 10)
    sum_c_t1 0 n

let kol_digit n predicat=
    let rec kol n acc=
        if n = 0 then acc
        else 
        if predicat (n % 10) then kol (n / 10) (acc + 1) else kol (n / 10) acc
    kol n 0

let kol_del n=
    let rec kol digit i ans=
        if i >= digit then ans 
        else if digit % i = 0 then kol digit (i+1) (ans + 1) else kol digit (i + 1) ans
    kol n 2 0

let proverka_on_prost digit=
    if kol_del digit > 0 then false else true

let m1 n=
    let list_del= create_del_list n 1 []
    sum_list list_del 0 proverka_on_prost

let m2 n=
    kol_digit n (fun x -> ((x % 2) > 0) && (x > 3))

let m3 n=
    mult_list (create_del_list n 1 []) 1 (fun x -> sum_c_t x > sum_c_t n)  

[<EntryPoint>]
let main argv =
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine(m1 n)
    System.Console.WriteLine(m2 n)
    System.Console.WriteLine(m3 n)
    0