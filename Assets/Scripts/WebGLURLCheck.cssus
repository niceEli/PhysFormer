using UnityEngine;
using UnityEngine.Networking;

public class WebGLURLCheck : MonoBehaviour
{
    public string remoteURL = "https://niceeli.github.io/gamesAllowedURLS.txt"; // URL of the remote text file
    public string banMessage = "";

    private bool isBanned = false;
    private string[] allowedURLs;

    private void Start()
    {
        LoadAllowedURLs();
    }

    private void Update()
    {
        if (isBanned)
        {
            long storedTime = long.Parse(PlayerPrefs.GetString("bt", "0"));
            long currentTime = GetCurrentUnixTime();

            if (storedTime > currentTime)
            {
                long remainingTime = storedTime - currentTime;
                banMessage = "You are banned for " + (remainingTime / 60) + " minutes";
            }
            else
            {
                isBanned = false;
                banMessage = "";
            }
        }
    }

    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer && !isBanned)
        {
            long storedTime = long.Parse(PlayerPrefs.GetString("bt", "0"));

            if (!IsURLAllowed(Application.absoluteURL) || storedTime > GetCurrentUnixTime())
            {
                isBanned = true;
            }
        }
    }

    void LoadAllowedURLs()
    {
        StartCoroutine(DownloadURLFile());
    }

    IEnumerator DownloadURLFile()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(remoteURL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string[] lines = www.downloadHandler.text.Split('\n');
                allowedURLs = lines;

                CheckCurrentURL();
            }
            else
            {
                Debug.LogError("Failed to download the URL file. Error: " + www.error);
            }
        }
    }

    void CheckCurrentURL()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer && !isBanned)
        {
            string currentURL = Application.absoluteURL;

            if (!IsURLAllowed(currentURL))
            {
                long unixTime = GetCurrentUnixTime() + (10 * 60); // Add 10 minutes in seconds

                PlayerPrefs.SetString("bt", unixTime.ToString());
                PlayerPrefs.Save();
            }
        }
    }

    bool IsURLAllowed(string url)
    {
        if (allowedURLs != null)
        {
            foreach (string allowedURL in allowedURLs)
            {
                if (url.Contains(allowedURL))
                    return true;
            }
        }

        return false;
    }

    long GetCurrentUnixTime()
    {
        System.DateTime currentTime = System.DateTime.UtcNow;
        System.DateTime epochTime = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

        long unixTime = (long)(currentTime - epochTime).TotalSeconds;
        return unixTime;
    }
}
