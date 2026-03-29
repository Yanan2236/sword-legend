# Development Conventions

## State classes
- 状態保持用クラスは、基本的に `SerializeField + private field + public getter` を用いる
- 外部からの直接代入は避ける

## Namespace
- 新規クラスには namespace を付ける
- Run 関連のクラスは `Game.Run` を使用する