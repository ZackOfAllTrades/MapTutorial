using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Tests : MonoBehaviour
{
    void Awake()
    {
        //TaskUtils.Init();

        //Action k = () =>
        //{
        //    GameObject.Find("Main Camera");
        //    Debug.Log("YEAH");
        //};
        //Action kk = () => Debug.Log("easy");

        //TaskUtils.FireAndForget(kk,(e) => Debug.LogError("OUCH " + e));


        //Task.Run(() => Debug.Log("START"))
        //    .ContinueWith(() => Debug.LogError("OUCH"), TaskContinuationOptions.OnlyOnFaulted)
        //    .ContinueWith(() => Debug.Log("NICE");

        //TaskUtils.FireAndForget(k, (exception) => Debug.LogError($"OUCH {exception}")).ContinueWith((t) => Debug.Log("Succefful" + t.IsFaulted), TaskContinuationOptions.OnlyOnRanToCompletion);

        //var task = Task.Run(kk);
        //task.ContinueWith((t) => Debug.Log(" Success "), TaskContinuationOptions.OnlyOnRanToCompletion);
        //task.ContinueWith((t) => Debug.Log(" OUCH " + t.IsFaulted), TaskContinuationOptions.OnlyOnFaulted);

        //TaskUtils.FireAndForgetUnity(k, k, (e) => Debug.LogError("OUCH " + e));


        //TaskUtils.FireAndForgetUnity(kk,() => k(),(e) => Debug.LogError("OUCHY " + e));

        //Task.Run(() => { }).ContinueWith((t) => k());

        //Debug.Log($"Hi from unity thread: {Thread.CurrentThread.ManagedThreadId}");
        //Task.Run(() => Debug.Log($"hey from thread {Thread.CurrentThread.ManagedThreadId}"));

        //try
        //{
        //    Task.Run(() =>
        //    {
        //        try
        //        {
        //            var k = GameObject.Find("Main Camera");
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.Log("INNNER " + e);
        //            throw e;
        //        }
        //    });
        //}
        //catch (Exception e)
        //{
        //    Debug.LogError("OUTTER " + e);
        //}

        //Task.Factory.StartNew(() => { }).ContinueWith((t) => { },TaskContinuationOptions.;

        //Task.Factory.StartNew<bool>(() =>
        //{

        //}, tokenSource.Token, TaskCreationOptions.LongRunning).ContinueWith(faultedTask =>
        //{
        //    WriteExceptionToLog(faultedTask.Exception);
        //}, TaskContinuationOptions.OnlyOnFaulted);
    }
}
