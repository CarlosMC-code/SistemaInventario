@echo off
setlocal
pushd "%~dp0.."
where msbuild >nul 2>nul
if errorlevel 1 (
  echo Abre este script desde Developer Command Prompt de Visual Studio.
  popd
  exit /b 1
)
msbuild "src\SistemaInventario.sln" /restore /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU"
if errorlevel 1 (
  popd
  exit /b 1
)
set "inventario_salida=src\SistemaInventario.Presentacion\bin\Release\net48"
if not exist "%inventario_salida%\SistemaInventario.Presentacion.exe" (
  echo No se encontro el ejecutable Release.
  popd
  exit /b 1
)
copy /Y "%inventario_salida%\*.exe" "build\" >nul
if errorlevel 1 exit /b 1
copy /Y "%inventario_salida%\*.dll" "build\" >nul
if errorlevel 1 exit /b 1
copy /Y "%inventario_salida%\*.exe.config" "build\" >nul
if errorlevel 1 exit /b 1
echo Compilacion Release copiada a build.
popd
endlocal
