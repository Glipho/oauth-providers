# Glipho OAuth Providers
## Description
An implementation of the OAuth 1.0 provider for DotNetOpenAuth. This is our internal proposed implementation and we wanted to open source to get feedback and to help other people get their own OAuth provider off the ground. Right now this is not in production but will be soon. Feel free to contribute, pick apart and generally run the rule over the project.

## Why
We want to create our own API and secure access to it. After much research it appears that OAuth 1.0 is the way to go. The OAuth 2.0 spec is not fully finalised and is much harder to implement on a server side than OAuth 1.0. 

We chose to use DotNetOpenAuth as it has taken care of much of the implementation and security details for implementing OAuth however, all examples we found seemed to use only SQL server and Entity Framework. We prefer to use [MongoDB](http://mongodb.org), but also believe you should be able to easily drop in any database provider you like. As such all database operations are implemented against interfaces and anyone wishing to write their own implementation can go ahead and do so.

## Sample WebAPI Implementation
We have created a sample application which will demonstrate the basics of how to use this library and how we intend to use it. It can be found [here](https://github.com/Glipho/oauth-provider-webapi-sample).

## Installation
You are of course welcome to download and build the source using Visual Studio 2012 and .Net 4.5. However the recommend way is to get it via the NuGet package found here.

## Contributing
We welcome, and actively encourage, contributions. If you wish to contribute following the few simple rules below would be great.

- Open (or ensure there is) an Issue for the bug you have found or the feature you want to contribute.
- Ensure there are relevant unit tests (yes we know there are no unit tests yet, feel free to add them). We prefer to use xUnit.
- Make sure pull requests are against the “dev” branch.
- Don’t change version numbers. We’ll do that when we merge into the master branch

## Authors
**James Toyer**
- [http://glipho.com/jamestoyer](http://glipho.com/james)
- [http://github.com/jamestoyer](http://github.com/jamestoyer)

## Copyright and Licence
Copyright (c) 2013 Glipho Ltd

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
