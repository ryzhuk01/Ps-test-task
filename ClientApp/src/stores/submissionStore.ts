import { defineStore } from 'pinia';
import { ref } from 'vue';
import { useSubmissions } from '../composables/useSubmissions';
import type { FormSubmission, CreateSubmissionRequest } from '../types/submission';

export const useSubmissionStore = defineStore('submission', () => {
    const submissions = ref<FormSubmission[]>([]);
    const { isLoading, error, fetchSubmissions: apiFetch, createSubmission: apiCreate } = useSubmissions();

    const fetchSubmissions = async (search?: string) => {
        const data = await apiFetch(search);
        submissions.value = data;
    };

    const createSubmission = async (data: CreateSubmissionRequest) => {
        await apiCreate(data);
        await fetchSubmissions();
    };

    return {
        submissions,
        isLoading,
        error,
        fetchSubmissions,
        createSubmission,
    };
});
