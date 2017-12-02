open System.IO



let lines = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "day2_input.txt"))

let parseLine (line: string) =
    line.Split ()
    |> Array.map int

let part1 lines =
    lines
    |> Array.map parseLine
    |> Array.map (fun arr ->
        let max' = Array.max arr
        let min' = Array.min arr
        max' - min')
    |> Array.sum

let findDevide arr =
    let sorted = Array.sortDescending arr
    let l = Array.length arr
    let rec check l (arr: int[]) i =
        let recur = check l arr
        let rec loop n l (arr: int[]) j =
            let recur = loop n l arr
            if j >= l then None
            else
                if n % arr.[j] = 0 then Some(n / arr.[j])
                else recur (j + 1)
        match loop arr.[i] l arr (i+1) with
        | None -> recur (i+1)
        | Some v -> v
    check l sorted 0

let part2 lines =
    lines
    |> Array.map parseLine
    |> Array.map findDevide
    |> Array.sum

part2 lines
|> printfn "%d"

