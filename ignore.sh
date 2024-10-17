#!/bin/bash

echo "VERCEL_GIT_COMMIT_REF: $VERCEL_GIT_COMMIT_REF"
echo "VERCEL_GIT_PULL_REQUEST_ID: $VERCEL_GIT_PULL_REQUEST_ID"
echo "VERCEL_GIT_COMMIT_MESSAGE: $VERCEL_GIT_COMMIT_MESSAGE"
echo "VERCEL_GIT_REPO_SLUG: $VERCEL_GIT_REPO_SLUG"
echo "VERCEL_GIT_REPO_OWNER: $VERCEL_GIT_REPO_OWNER"

stringContain() { case $2 in *$1* ) return 0;; *) return 1;; esac ;}

# cancel build on release please branches 
if stringContain "release-please" "$VERCEL_GIT_COMMIT_REF" ; then
  # Don't build
    echo "🛑 - Build cancelled: Release Please branch"
  exit 0;
fi

# if commit message contains "nopreview" then cancel build
if stringContain "nopreview" "$VERCEL_GIT_COMMIT_MESSAGE" ; then
  # Don't build
    echo "🛑 - Build cancelled: No preview for this change"
  exit 0;
fi

# if commit message contains "deploy:" then allow build
if stringContain "deploy:" "$VERCEL_GIT_COMMIT_MESSAGE" ; then
  # Proceed with the build
    echo "✅ - Build can proceed: deploy commit"
  exit 1;
fi

# if pr is not empty then allow build
if [ -n "$VERCEL_GIT_PULL_REQUEST_ID" ]; then
  # Proceed with the build
    echo "✅ - Build can proceed: PR"
  exit 1;
fi


# Cancel build by default
echo "🛑 - Build cancelled"
exit 0;