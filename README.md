# CompetitionProgrammingJudgeSystemDotnetLibrary


## サンプル

かなり本気なサンプルコードです。

この中で登場するコントロールとイベントが作成されていれば、しっかりと動きます。

詳細説明は今後追加していきます。

##### Form1 フォームのコントロール
- comboBox1 : 問題のタイトルを選択するコンボボックス
- comboBox2 : 回答の言語を選択するコンボボックス
- button1 : 回答を送信するボタン
- richTextBox1 : コードを記述するリッチテキストボックス
- webBrowser1 : 問題の内容を表示するウェブブラウザ

##### Form1 フォームのイベント
- Form1_Load : フォームのロード時
- comboBox1_SelectedIndexChanged : comboBox1 の選択変更時
- button1_Click : button1のクリック時

その他、分からない点やおかしい点がありましたら、Issueにてお問い合わせください。

```csharp
using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using CompetitionProgrammingJudgeSystemDotnetLibrary;

namespace CompetitionProgrammingJudgeSystemDotnetLibrarySample {
  public partical class Form1 : Form {
  	public Form1() {
  		InitializeComponent();
  	}
  	
  	// すべての問題を格納する配列
  	private Question[] questions;
  	
  	// プログラムが起動した時
  	private async void Form1_Load(object sender, EventArgs e) {
  		// すべての問題を非同期に取得
  		questions = await Request.GetQuestionsAsync();
  		
  		// すべての問題のタイトルを comboBox1 に追加
  		questions.Select(question => comboBox1.Items.Add(question.Title));
  		
  		// すべてのプログラミング言語を comboBox2 に追加
  		typeof(Language).GetEnumNames().Select(language => comboBox2.Items.Add(language));
  	}
  	
  	// comboBox1 の選択が変更された時
  	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
  		// 選択中の問題の内容を表示
  		webBrowser1.DocumentText = getSelectedQuestion().BodyHtml;
  	}
  	
  	// ボタンが押された時
  	private async void button1_Click(object sender, EventArgs e) {
  		// 選択中の問題を取得
  		Question question = getSelectedQuestion();
  		
	 		// 選択中のプログラミング言語を取得
	 		Language language = getSelectedLanguage();
	 		
	 		// 回答を非同期に提出
  		bool success = await Request.SubmitAnswerAsync(question.Id, richTextBox1.Text, language);
  		
  		// 結果を文字列に変換
  		string message = (success) ? "正解" : "不正解";
  		
  		// 結果を表示
  		MessageBox.Show(message);
  	}
  	
  	// 選択中の問題を取得
  	private Question getSelectedQuestion() {
  		return questions.Where(question => comboBox1.SelectedItem.ToString() == question.Title).FIrst();
  	}
  	
  	// 選択中のプログラミング言語を取得
  	private Language getSelectedLanguage() {
  		return (Language)comboBox2.SelectedItem;
  	}
  }
}
```