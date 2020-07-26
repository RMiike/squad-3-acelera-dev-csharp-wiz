import React, {useState, useCallback} from 'react';
import LinearGradient from 'react-native-linear-gradient';
import {StyleSheet, Modal, Platform, Alert} from 'react-native';
import {
  Textarea,
  Text,
  FormArea,
  Icon,
  Form,
  Input,
  MailIcon,
  ButtonArea,
  AreaInput,
  ButtonText,
} from './styles';
import api from '../../services/api';
import * as Yup from 'yup';

const ForgotPassword: React.FC = (props) => {
  const {isVisible, handleViewForgotPass} = props;
  const [email, setEmail] = useState();

  const handleForgotPassword = useCallback(async () => {
    try {
      const yupSchema = Yup.object().shape({
        email: Yup.string()
          .required('Required email field')
          .email('Invalid email'),
      });
      await yupSchema.validate({email}, {abortEarly: false});
      const resp = await api.post('forgotpassword', {email});

      Alert.alert(
        'Successfuly reseted.',
        `A new password has been sent to the email: ${email}`,
      );
      handleViewForgotPass();
    } catch (e) {
      Alert.alert('Invalid email', 'Verify your email and try again.');
    }
  }, []);
  return (
    <Modal transparent={true} visible={isVisible}>
      <LinearGradient
        colors={[
          '#28023Daa',
          'rgba(51, 21, 72, 0.44)',
          'rgba(79, 69, 100, 0.5)',
        ]}
        style={styles.linearGradient}>
        <FormArea
          behavior={Platform.OS === 'ios' ? 'padding' : undefined}
          enabled>
          <Icon
            name="x"
            size={20}
            color="#fff"
            onPress={handleViewForgotPass}
          />
          <Textarea>
            <Text>Forgot your password?</Text>
          </Textarea>
          <Form>
            <AreaInput>
              <MailIcon name="mail" size={20} color="#f29657" />
              <Input
                placeholder="E-mail"
                autoCorrect={false}
                autoCapitalize="none"
                value={email}
                onChangeText={(text) => setEmail(text)}
              />
            </AreaInput>
            <ButtonArea onPress={handleForgotPassword}>
              <ButtonText>Enter</ButtonText>
            </ButtonArea>
          </Form>
        </FormArea>
      </LinearGradient>
    </Modal>
  );
};

export default ForgotPassword;
var styles = StyleSheet.create({
  linearGradient: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    padding: 60,
    borderRadius: 15,
  },
});
