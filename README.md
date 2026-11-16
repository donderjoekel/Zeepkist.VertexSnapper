# Zeepkist.VertexSnapper

A Zeepkist level editor mod that snaps selected blocks together by their vertices.

Originally created by Timo ([YoloDevDE](https://github.com/YoloDevDE/VertexSnapper)); history imported from that repository.

## Build

```powershell
dotnet build Zeepkist.VertexSnapper.csproj -c Debug
```

The build output contains `VertexSnapper.dll` and `assets/wireframe`, which the plugin loads at runtime. On Windows, with Zeepkist installed in the default Steam location, a Debug build is also copied to `BepInEx/plugins/Sideloaded/Plugins/VertexSnapper`.

## Releasing

Go to **Actions → release → Run workflow** and pick a **bump** (patch, minor or major) and a **stage**. A `stable` release goes to GitHub and mod.io. An `alpha`, `beta` or `rc` stage only creates a GitHub pre-release. The version is worked out from the latest git tag and written back into the csproj. Don't edit `<Version>` by hand; PRs that do are rejected.

The pipeline lives in [donderjoekel/zeepkist-mod-workflows](https://github.com/donderjoekel/zeepkist-mod-workflows).
