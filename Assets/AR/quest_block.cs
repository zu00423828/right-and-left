using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class quest_block : MonoBehaviour {
    public int index;
    public int endindex=10;
    public int score;
    public Text question_text;
    public Text score_text;
    public Text endtitle;
    public Button start;
    public Button rest;
    public Dropdown ch;
    public GameObject[] answer=new GameObject[2];
    public List<questionbankData> questionbank_data;
    public bool change;
    public int rand;
    public Text hight;
    public GameObject high;
    public Button shot;
    public Text i_d;
    public InputField id;
    public Text pr_id;
    public Button hit;
    public GameObject hit_box;
    public GameObject title;
    // Use this for initialization
    void Start ()
    {
        hight.text = PlayerPrefs.GetInt("hightscore").ToString();
        //ch.options.Clear();
        DataPool.f_InitPool();
        questionbank_data = DataPool.m_questiondt.dataList;
        for (int j=9;j<questionbank_data.Count;j+=10)
        {
            ch.options.Add(new Dropdown.OptionData { text = questionbank_data[j].Chname });
        }
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //print("index "+index+"\tend "+endindex);
        if (change == false)
        {
            if (index<endindex)
                question_text.text = questionbank_data[index].Questionvalue;     
            else
            {
                CancelInvoke();
                question_text.gameObject.SetActive(false);
                endtitle.gameObject.SetActive(true);
                endtitle.text = "GOOD JOB";
                rest.gameObject.SetActive(true);
                if (PlayerPrefs.GetInt("hightscore") <= score)
                {
                    PlayerPrefs.SetInt("hightscore", score);
                    PlayerPrefs.Save();
                }
            }
        }
        else
        {
            question_text.text = questionbank_data[rand].Questionvalue;
            index = rand;
        }
        score_text.text = "Score：" + score;
            if (IsInvoking()==false&&question_text.gameObject.active==true)
                Invoke("inst", 3);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.1f, true);
                Destroy(hit.transform.gameObject);

                if (hit.transform.tag == questionbank_data[index].Answer.ToString().ToLower())
                {
                    Destroy(hit.transform.gameObject);
                    score += 10;
                    print("答對");
                    if (ch.value != 0)
                    {
                        index++;
                    }
                    else
                    {
                        random();
                    }
                       
                }
                else
                {
                    Destroy(hit.transform.gameObject);
                    print("答錯");
                    question_text.gameObject.SetActive(false);
                    CancelInvoke();
                    endtitle.gameObject.SetActive(true);
                    endtitle.text = "GAME OVER";
                    rest.gameObject.SetActive(true);
                    if (PlayerPrefs.GetInt("hightscore") <= score)
                    {
                        PlayerPrefs.SetInt("hightscore", score);
                        PlayerPrefs.Save();
                    }
                }
          
            }

    }
    void inst()
    {
        Instantiate(answer[0]);
        Instantiate(answer[1]);
    }
    public void startonclick()
    {
        high.SetActive(false);
        question_text.gameObject.SetActive(true);
        score_text.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        ch.gameObject.SetActive(false);
        pr_id.gameObject.SetActive(true);
        i_d.gameObject.SetActive(false);
        hit.gameObject.SetActive(false);
        title.SetActive(false);
        if (ch.value != 0)
        {
            change = false;
            index = questionbank_data.FindIndex(x => x.Ch + 1 == ch.value);
            endindex = index + 10;
            
        }
        else
        {
            change = true;
            random();
        }
        print(ch.value);
        pr_id.text = "學號:"+id.text;
    }

    void random()
    {
        Random.seed = System.Guid.NewGuid().GetHashCode();
        rand = Random.Range(0, 159);
        print(rand);
    }

    public void restonclink()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void shotscreen()
    {
        Application.CaptureScreenshot(PlayerPrefs.GetInt("")+".jpg");
        PlayerPrefs.SetInt("", PlayerPrefs.GetInt("")+1);
        PlayerPrefs.Save();
    }

    public void hitclick()
    {
        hit_box.SetActive(true);
    }
    public void closeclick()
    {
        hit_box.SetActive(false);
    }
}
