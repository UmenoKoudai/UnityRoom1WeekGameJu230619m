プレイヤーの入力と解答の判定を行う方へ
・InputFieldのPrefabはCanvasの子オブジェクトにしてください。
・InputFieldのインスペクターの「OnSubmit」にTextSubmitクラスの「Submit()」を割り当てることで、
InputFieldに文字を入力してEnterを押すと、PlayerInputプロパティに入力した文字列が格納されるようになっています。
・プロパティは読み取り専用にしてあるので、入力を判定するクラスから適切なタイミングで参照するか、
判定を行うクラスのメソッドを、Submit()内で呼んでください。