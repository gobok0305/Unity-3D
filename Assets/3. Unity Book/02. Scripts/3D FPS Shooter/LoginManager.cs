using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField password;

    public TextMeshProUGUI notify;

    private void Start()
    {
        notify.text = "";
    }

    public void SaveUserData()
    {
        if (!CheckInput(id.text, password.text))
        {
            return;
        }

        if (!PlayerPrefs.HasKey(id.text))//현재 지정된 데이터 중에 동일한 id가 있는지 확인
        {
            PlayerPrefs.SetString(id.text, password.text);
            notify.text = "아이디 생성이 완료되었습니다!";
        }
        else //이미 존재한다면!
        {
            notify.text = "이미 존재하는 아이디입니다.";
        }
        
    }

    public void CkeckUserData()
    {
        // 아이디(key)에 저장된 패스워드(value)를 가져오는 기능
        string pass = PlayerPrefs.GetString(id.text); 
        if (password.text == pass)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            notify.text = "입력하신 아이디와 패스워드가 일치하지 않습니다.";
        }
    }

    private bool CheckInput(string id, string pwd) //입력유무 확인
    {
        if (id == "" || pwd == "")
        {
            notify.text = "아이디 또는 패스워드를 입력해주세요.";
            return false;
        }
        else
        {
            return true;
        }
    }

}
