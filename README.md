# Lambda issue

## Reproduce Issue

1. Clone this repo
2. Install Cake `dotnet tool install --global Cake.Tool`
3. Run `dotnet-cake` in the root of the repo. This will create the lambda package in the `lambda-publish` folder.
4. Open AWS console and navigate to Lambda
5. Create a new function
6. Select `Author from scratch`
7. Give it a name
8. Select `.Net 6` as the runtime
9. Click `Create function`
10. Click `Edit in Runtime settings`
11. Change Handler to `ProfileAPI` and click `Save`
12. Click `Upload from` and select the zip file in the `lambda-publish` folder
13. Click on `Test` and select `Create new test event`
14. Choose `api-gateway-aws-proxy` as the event template
15. Click `Test`

The above should recreate the error. The error is:

```
A fatal error was encountered. The library 'libhostpolicy.so' required to execute the application was not found in '/var/task/'.
Failed to run as a self-contained app.
- The application was run as a self-contained app because '/var/task/ProfileAPI.runtimeconfig.json' did not specify a framework.
- If this should be a framework-dependent app, specify the appropriate framework in '/var/task/ProfileAPI.runtimeconfig.json'.
A fatal error was encountered. The library 'libhostpolicy.so' required to execute the application was not found in '/var/task/'.
Failed to run as a self-contained app.
- The application was run as a self-contained app because '/var/task/ProfileAPI.runtimeconfig.json' did not specify a framework.
- If this should be a framework-dependent app, specify the appropriate framework in '/var/task/ProfileAPI.runtimeconfig.json'.
START RequestId: a73fb0a1-d2a0-41c2-90a4-44964414e26d Version: $LATEST
RequestId: a73fb0a1-d2a0-41c2-90a4-44964414e26d Error: Runtime exited with error: exit status 131
```