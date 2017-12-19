open System
open System.IO
open System.Text.RegularExpressions


let input = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "day7_input.txt"))

type Program = { name: string; weight: int }

type Tower<'t> =
    | Top of 't
    | Disk of p: 't * children: Tower<'t> list

let parseInput input =
    let parseLine line =
        let m = Regex.Match (line, "(?<name>\w+) \((?<weight>\d+)\)( -> (?<children>.+))?")
        let name = m.Groups.["name"].Value
        let weight = int m.Groups.["weight"].Value
        let childText = m.Groups.["children"].Value
        let children =
            if childText = "" then []
            else
                childText.Split(',')
                |> Array.map (fun s -> s.Trim())
                |> Array.toList
        name, weight, children

    let folder (dic, childList) line =
        let name, weight, children = parseLine line
        let dic' = Map.add name (weight, children) dic
        let childList' = [ yield! children; yield! childList ]
        dic', childList'

    let dic, childList = Array.fold folder (Map.empty, []) input
    let rootName = (dic |> Seq.find (fun kv -> not (List.contains kv.Key childList))).Key
    
    let rec buildTower dic name =
        let weight, children = Map.find name dic
        let p = {name = name; weight = weight}
        if List.isEmpty children then Top p
        else 
            Disk (p, children |> List.map (buildTower dic))

    buildTower dic rootName

let tower = parseInput input

let part1 () =
    match tower with
    | Top p | Disk (p, _) -> p.name

part1() |> printfn "%s"