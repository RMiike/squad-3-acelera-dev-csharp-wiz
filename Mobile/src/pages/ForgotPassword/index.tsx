import React from 'react';
import LinearGradient from 'react-native-linear-gradient';
import {Text, StyleSheet} from 'react-native';

const ForgotPassword: React.FC = () => {
  return (
    <LinearGradient
      colors={[
        '#28023D',
        'rgba(51, 21, 72, 0.854068)',
        'rgba(79, 69, 100, 0.5)',
      ]}
      style={styles.linearGradient}>
      <Text>Sign in with Facebook</Text>
    </LinearGradient>
  );
};

export default ForgotPassword;
var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
  },
});
