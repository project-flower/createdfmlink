# Introduction
C++Builder の.dfmファイルへのハード リンクを作成するバッチ ファイルを生成します。  

C++Builder の64-bit リンカ ILINK64.exe は、ライブラリ パスが多すぎるとリンクに失敗します。  
これに対応するため、プロジェクトが.dfmファイルのパスを管理しないように設定された状態で、  
.dfmファイルが一つのパスにコピーされるバッチ ファイルを作成します。  

# Getting Started
このアプリケーションの実行には、.NET Framework 4.6 が必要です。  
これを適用するプロジェクトはプロジェクト ファイル (.cbproj)の内容に以下の要素を記述します。  
これを設定されたプロジェクトは.dfm ファイルのパスをライブラリ パスに自動的に追加しません。  
`<ProjectProperties Name="ManagePaths">False</ProjectProperties>`  

createdfmlink.exe をビルドしたら、第一引数にプロジェクト ファイルを指定するか、エクスプローラでドラッグ&ドロップしてください。  
プロジェクト ファイルと同じ場所に、(プロジェクト名).createlink.bat と (プロジェクト名).deletelink.bat が作成されます。  
プロジェクトのリンク前イベントに .createlink.bat を、リンク後イベントに .deletelink.bat を実行するように設定してください。  
リンク前にプロジェクト ファイルと同じ場所に .dfm ファイル のハード リンクが作成され、リンク後に削除されます。  

# Build and Test
Visual Studio 2017 でビルドします。  

createdfmlink.sln を開き、createdfmlink をビルドしてください。  
ユニットテストはありません。
