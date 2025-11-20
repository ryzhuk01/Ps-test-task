<script setup lang="ts">
import DynamicForm from '../components/forms/DynamicForm.vue';
import SubmissionList from '../components/submissions/SubmissionList.vue';
import { useSubmissionStore } from '../stores/submissionStore';
import type { FormSchema } from '../types/form';

const store = useSubmissionStore();

const schema: FormSchema = {
  fields: [
    {
      name: 'productName',
      label: 'Product name',
      type: 'text',
      placeholder: 'Headphones',
      validation: [{ type: 'required' }, { type: 'minLength', params: 3 }]
    },
    {
      name: 'orderDate',
      label: 'Order date',
      type: 'date',
      validation: [
        { type: 'required' },
        { type: 'minDate', params: '1920-01-01', message: 'Date must be after 1920' },
        { type: 'maxDate', params: 'today', message: 'Date cannot be in the future' }
      ]
    },
    {
      name: 'category',
      label: 'Category',
      type: 'select',
      options: [
        { value: 'electronics', label: 'Electronics' },
        { value: 'clothing', label: 'Clothing' },
        { value: 'home', label: 'Home & Garden' },
        { value: 'books', label: 'Books' }
      ],
      validation: [{ type: 'required' }]
    },
    {
      name: 'paymentMethod',
      label: 'Payment method',
      type: 'radio',
      options: [
        { value: 'card', label: 'Credit Card' },
        { value: 'cash', label: 'Cash' },
        { value: 'paypal', label: 'PayPal' }
      ],
      validation: [{ type: 'required' }],
      value: 'card'
    },
    {
      name: 'giftWrap',
      label: 'Gift wrap',
      type: 'checkbox',
      validation: []
    }
  ]
};

const handleSubmit = async (formData: Record<string, any>) => {
  try {
    await store.createSubmission({
      formName: 'Product Order',
      formData
    });
  } catch (error) {
    console.error('Submission failed:', error);
  }
};
</script>

<template>
  <div class="home-view">
    <div class="content-wrapper">
      <section class="form-section">
        <h2>New Order</h2>
        <DynamicForm
          :schema="schema"
          @submit="handleSubmit"
          :is-loading="store.isLoading"
          submit-label="Place Order"
        />
      </section>

      <section class="list-section">
        <h2>Orders</h2>
        <SubmissionList />
      </section>
    </div>
  </div>
</template>

<style scoped lang="scss">
.home-view {
  padding: 2rem;
  max-width: 1200px;
  margin: 0 auto;
}

.content-wrapper {
  display: grid;
  grid-template-columns: 1fr;
  gap: 2rem;

  @media (min-width: 768px) {
    grid-template-columns: 1fr 1fr;
    align-items: start;
  }
}

h2 {
  margin-bottom: 1.5rem;
  color: #2c3e50;
  border-bottom: 2px solid #42b983;
  padding-bottom: 0.5rem;
  display: inline-block;
}
</style>
