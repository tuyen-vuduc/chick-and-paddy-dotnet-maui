
cd src/ChickAndPaddy
dotnet publish -f net8.0-android -c Release \
    -p:AndroidKeyStore=true \
    -p:AndroidSigningKeyStore=x_release.keystore \
    -p:AndroidSigningKeyAlias=$KEYSTORE_ALIAS \
    -p:AndroidSigningKeyPass=$KEYSTORE_PASSWORD \
    -p:AndroidSigningStorePass=$KEYSTORE_PASSWORD