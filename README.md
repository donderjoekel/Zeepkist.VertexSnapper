# Zeepkist.VertexSnapper

A Zeepkist level editor mod that snaps selected blocks together by their vertices.

Originally created by Timo ([YoloDevDE](https://github.com/YoloDevDE/VertexSnapper)); history imported from that repository.

## Build

```powershell
dotnet build Zeepkist.VertexSnapper.csproj -c Debug
```

The build output contains `VertexSnapper.dll` and `assets/wireframe`, which the plugin loads at runtime. On Windows, with Zeepkist installed in the default Steam location, a Debug build is also copied to `BepInEx/plugins/Sideloaded/Plugins/VertexSnapper`.
